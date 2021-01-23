    using System;
    using System.Collections.Concurrent;
    public class Globals
    {
        public static MsgBus Events = new MsgBus();
    }
    public class MsgBus
    {
        private readonly ConcurrentDictionary<dynamic, MsgChannel> channels = new ConcurrentDictionary<dynamic, MsgChannel>();
        public MsgChannel this[dynamic channel]
        {
            set { channels[channel] = value; }
            get
            {
                var subject = (MsgChannel)channels.GetOrAdd(channel, new MsgChannel());
                return subject;
            }
        }
        private MsgChannel broadcast = new MsgChannel();
        public void Send(dynamic msg)
        {
            broadcast.Send(msg);
        }
        public static MsgBus operator +(MsgBus left, Action<dynamic> right)
        {
            left.broadcast += right;
            return left;
        }
        public static MsgBus operator -(MsgBus left, Action<dynamic> right)
        {
            left.broadcast -= right;
            return left;
        }
    }
    public class MsgChannel
    {
        ConcurrentDictionary<Action<dynamic>, int> observers = new ConcurrentDictionary<Action<dynamic>, int>();
        public void Send(dynamic msg)
        {
            foreach (var observer in observers)
            {
                for (int i = 0; i < observer.Value; i++)
                {
                    observer.Key.Invoke(msg);
                }
            }
        }
        public static MsgChannel operator +(MsgChannel left, Action<dynamic> right)
        {
            if (!left.observers.ContainsKey(right))
            {
                left.observers.GetOrAdd(right, 0);
            }
            left.observers[right]++;
            return left;
        }
        public static MsgChannel operator -(MsgChannel left, Action<dynamic> right)
        {
            if (left.observers.ContainsKey(right) &&
                left.observers[right] > 0)
            {
                left.observers[right]--;
                int dummy;
                if (left.observers[right] <= 0) left.observers.TryRemove(right, out dummy);
            }
            return left;
        }
    }
