using System;
using System.IO;
static void Main(string[] args)
{
    string fileName = "abc.txt";
    if (!File.Exists(fileName))
        return;
    using (FileStream file = File.OpenRead(fileName))
    using (StreamReader reader = new StreamReader(file))
    {
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
        }
    }
}
