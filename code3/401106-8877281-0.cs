    using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.IO;
        using System.Threading;
        using System.IO.MemoryMappedFiles;
        
        
        namespace ProcesComunication
        {
            class Program
            {
                static void Main(string[] args)
                {
                    MemoryMappedFile mmf = MemoryMappedFile.CreateNew("AAB", 1024);
                    MemoryMappedViewStream mStream = mmf.CreateViewStream();
                    BinaryWriter bw = new BinaryWriter(mStream);
                    Mutex mx = new Mutex(true, "sync");
                    while (true)
                    {
                        mx.WaitOne();
                        Thread.Sleep(2000);
                        var random = new Random();
                        var nextValue = random.Next().ToString();
                        Console.WriteLine(nextValue);
                        bw.Write(nextValue);
                        mx.ReleaseMutex();
                    }
                    bw.Close();
                    mStream.Close();
                   
                }
            }
        }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading;
    using System.IO.MemoryMappedFiles;
    
    namespace ProcesRead
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("AAB");
                MemoryMappedViewStream mStream = mmf.CreateViewStream();
                BinaryReader br = new BinaryReader(mStream);
    
                Mutex emx = Mutex.OpenExisting("sync");
             while (true)
                {
                    Console.WriteLine(br.ReadString());
                    emx.WaitOne(2000);
                }
                br.Close();
                mStream.Close();
               
            }
        }
    }
