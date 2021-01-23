    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;
    using System.Threading;
    namespace App
    {
        class FileInfo
        {
            public int HostId { get; set; }
            public string Extension { get; set; }
            public string FolderPath { get; set; }
        }
        class ThreadSet
        {
            public ThreadStart action;
            public FileInfo file;
            public string name;
            public Boolean shouldrun = true;
            public Thread thread;
            public ThreadSet(XElement host, Action<Object> threadaction)
            {
                int hostID = (int)host.Attribute("id");
                name = string.Format("samplethread{0}", hostID);
                file = new FileInfo
                    {
                        HostId = hostID,
                        Extension = (string)host.Element("Extension"),
                        FolderPath = (string)host.Element("FolderPath")
                    };
                action = () =>
                {
                    while (shouldrun)
                    {
                        threadaction(file);
                    }
                };
                thread = new Thread(action);
                thread.Name = name;
            }
            public void Start()
            {
                thread.Start();
            }
            public void Join()
            {
                shouldrun = false;
                thread.Join(5000);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var xDoc = XDocument.Load(string.Format(Path.Combine(currentDir, "Hosts.xml")));
                var threads = new List<ThreadSet>();
                foreach (XElement host in xDoc.Descendants("Host"))
                {
                    ThreadSet set = new ThreadSet(host, DoWork);
                    set.Start();
                    threads.Add(set);
                }
                //Carry on with your other work, then wait for worker threads
                threads.ForEach(t => t.Join());
            }
            static void DoWork(object threadState)
            {
                var fileInfo = threadState as FileInfo;
                if (fileInfo != null)
                {
                    //Do stuff here
                }
            }
        }
    }
