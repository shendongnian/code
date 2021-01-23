    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    internal class Program
    {
        private static void Main(string[] args)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork2);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            Console.WriteLine(string.Join(" | ", GetEventSubscribers(worker, "DoWork").Select(d => d.Method.Name).ToArray()));
        }
        static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
        static void worker_DoWork2(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
        static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        public static Delegate[] GetEventSubscribers(object target, string eventName)
        {
            Type t = target.GetType();
            var eventInfo = t.GetEvent(eventName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            do
            {
                FieldInfo[] fia = t.GetFields(
                     BindingFlags.Static |
                     BindingFlags.Instance |
                     BindingFlags.NonPublic);
                foreach (FieldInfo fi in fia)
                {
                    if (fi.Name == eventName)
                    {
                        Delegate d = fi.GetValue(target) as Delegate;
                        if (d != null)
                            return d.GetInvocationList();
                    }
                    else if (fi.FieldType == typeof(EventHandlerList))
                    {
                        dynamic obj = fi.GetValue(target) as EventHandlerList;
                        var eventHandlerFieldInfo = obj.GetType().GetField("head", BindingFlags.Instance | BindingFlags.NonPublic);
                        do
                        {
                            var listEntry = eventHandlerFieldInfo.GetValue(obj);
                            var handler = listEntry.GetType().GetField("handler", BindingFlags.Instance | BindingFlags.NonPublic);
                            if (handler != null)
                            {
                                var subD = handler.GetValue(listEntry) as Delegate;
                                if (subD.GetType() != eventInfo.EventHandlerType)
                                {
                                    eventHandlerFieldInfo = listEntry.GetType().GetField("next", BindingFlags.Instance | BindingFlags.NonPublic);
                                    obj = listEntry;
                                    continue;
                                }
                                if (subD != null)
                                {
                                    return subD.GetInvocationList();
                                }
                            }
                        }
                        while (eventHandlerFieldInfo != null);
                    }
                }
                t = t.BaseType;
            } while (t != null);
            return new Delegate[] { };
        }
    }
