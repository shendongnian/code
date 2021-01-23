    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            //Class to represent each frame
            public class Frame
            {
                //constructor..
                public Frame(string number, string position)
                {
                    Number = number;
                    Position = position;
                }
    
                public string Number { get; set; }
                public string Position { get; set; }
            }
    
            static void Main(string[] args)
            {
                string path = "c:\\data.txt";
                IList<Frame> AllFrames = new List<Frame>();
                
                foreach (string line in File.ReadLines(path))
                {
                    //split each line at the space
                    string[] parts = line.Split(' '); 
    
                    //Create a new Frame and add it to the list
                    Frame newFrame = new Frame(parts[0], parts[1]);
                    AllFrames.Add(newFrame);
                }
            }
        }
    }
