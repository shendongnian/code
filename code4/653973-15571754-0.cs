    using System;
    using System.Threading;
    #pragma warning disable 420
    namespace Tychaia.Threading
    {
        public class TaskPipeline<T>
        {
            private int? m_InputThread;
            private int? m_OutputThread;
            private volatile Entry m_Head;
            private sealed class Entry
            {
                public static readonly Entry Sentinel = new Entry(default(T));
                public readonly T Value;
                public Entry Next;
                public Entry(T value)
                {
                    Value = value;
                    Next = null;
                }
            }
            /// <summary>
            /// Creates a new TaskPipeline with the current thread being
            /// considered to be the input side of the pipeline.  The
            /// output thread should call Connect().
            /// </summary>
            public TaskPipeline()
            {
                this.m_InputThread = Thread.CurrentThread.ManagedThreadId;
                this.m_OutputThread = null;
            }
            /// <summary>
            /// Connects the current thread as the output of the pipeline.
            /// </summary>
            public void Connect()
            {
                if (this.m_OutputThread != null)
                    throw new InvalidOperationException("TaskPipeline can only have one output thread connected.");
                this.m_OutputThread = Thread.CurrentThread.ManagedThreadId;
            }
            /// <summary>
            /// Puts an item into the queue to be processed.
            /// </summary>
            /// <param name="value">Value.</param>
            public void Put(T value)
            {
                if (this.m_InputThread != Thread.CurrentThread.ManagedThreadId)
                    throw new InvalidOperationException("Only the input thread may place items into TaskPipeline.");
            retry:
                // Walk the queued items until we find one that
                // has Next set to null.
                var head = this.m_Head;
                while (head != null)
                {
                    if (head.Next != null)
                        head = head.Next;
                    if (head.Next == null)
                        break;
                }
                if (head == null)
                {
                    if (Interlocked.CompareExchange(ref m_Head, new Entry(value), null) != null)
                        goto retry;
                }
                else
                {
                    if (Interlocked.CompareExchange(ref head.Next, new Entry(value), null) != null)
                        goto retry;
                }
            }
            /// <summary>
            /// Takes the next item from the pipeline, or blocks until an item
            /// is recieved.
            /// </summary>
            /// <returns>The next item.</returns>
            public T Take()
            {
                if (this.m_OutputThread != Thread.CurrentThread.ManagedThreadId)
                    throw new InvalidOperationException("Only the output thread may retrieve items from TaskPipeline.");
            retry:
                // Wait until there is an item to take.
                var spin = new SpinWait();
                while (this.m_Head == null)
                    spin.SpinOnce();
                // Return the item and exchange the current head with
                // the next item, all in an atomic operation.
                Entry head = m_Head;
                Entry next = head.Next;
                // replace m_Head.Next with a non-null sentinel to ensure Put won't try to reuse it
                if (Interlocked.CompareExchange(ref head.Next, Entry.Sentinel, head.Next) != next)
                    goto retry;
                m_Head = next;
                return head.Value;
            }
        }
    }
