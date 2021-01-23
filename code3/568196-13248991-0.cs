    using System;
    using System.IO;
    
    namespace nsStreams
    {
        public class Redirect
        {
            static public void Main ()
            {
                FileStream ostrm;
                StreamWriter writer;
                TextWriter oldOut = Console.Out;
                try
                {
                    ostrm = new FileStream ("./Target.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new StreamWriter (ostrm);
                }
                catch (Exception e)
                {
                    Console.WriteLine (e.Message);
                    return;
                }
                Console.SetOut (writer);
               
                Console.SetOut (oldOut);
                writer.Close();
                ostrm.Close();
                Console.WriteLine ("Done");
            }
        }
    }
     
