    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace WeirdnessExample
    {
        public struct RawData
        {
            private readonly int id;
    
            public int ID
            {
                get{ return id;}
            }
    
            public RawData(int newID)
            {
                id = newID;
            }
        }
    
        public class ProcessedData
        {
            private readonly int id;
    
            public int ID
            {
                get{ return id;}
            }
            public ProcessedData(int newID)
            {
                id = newID;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<ProcessedData> processedRecords = new List<ProcessedData>();
                processedRecords.Add(new ProcessedData(1));
    
    
                List<RawData> rawRecords = new List<RawData>();
                rawRecords.Add(new RawData(2));
    
    
                for (int i = 0; i < rawRecords.Count; i++)
                {
                    RawData rawRec = rawRecords[i];
                    int id = rawRec.ID;
                    if (i < 0 || i > 20)
                    {
                        RawData rawRec2 = rawRec;
                        List<ProcessedData> matchingRecs = processedRecords.FindAll(mr => mr.ID == rawRec2.ID);
                    }
    
                    Console.Write(String.Format("With LINQ: ID Before Assignment = {0}, ", rawRec.ID)); //2
                    rawRec = new RawData(rawRec.ID + 8);
                    Console.WriteLine(String.Format("ID After Assignment = {0}", rawRec.ID)); //2
                    i++;
                }
    
                rawRecords = new List<RawData>();
                rawRecords.Add(new RawData(2));
    
                for (int i = 0; i < rawRecords.Count; i++)
                {
                    RawData rawRec = rawRecords[i];
                    int id = rawRec.ID;
                    if (i < 0)
                    {
                        List<ProcessedData> matchingRecs = processedRecords.FindAll(mr => mr.ID == id);
                    }
                    Console.Write(String.Format("With LINQ: ID Before Assignment = {0}, ", rawRec.ID)); //2
                    rawRec = new RawData(rawRec.ID + 8);
                    Console.WriteLine(String.Format("ID After Assignment = {0}", rawRec.ID)); //10
                    i++;
                }
    
                Console.ReadLine();
            }
        }
    }
