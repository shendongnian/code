    using System;
    using System.IO;
    class Program {
        static void Main() {
    	    foreach (string line in File.ReadAllLines("file.txt")) {
    	         string[] linesplit = line.Split(' ');
    	         // linesplit has your elements, do your db stuff
    	    }
        }
    }
