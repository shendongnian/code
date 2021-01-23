    using System;
    using System.IO;
    class Program {
        static void Main() {
            StreamReader sr = new StreamReader("file.txt");
    	    while ((line = sr.ReadLine()) != null) {
    	         string[] linesplit = line.Split(' ');
    	         // linesplit has your elements, do your db stuff
    	    }
        }
    }
