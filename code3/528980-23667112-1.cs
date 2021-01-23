    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    class Program
    {
    static void Main() {
    string s1 = @"[Wsg-Fs]-A-A-A-Cgbs-Sg7-[Wwg+s-Fs]-A-A-Afk-Cgbs-Sg7";
    var myRegex = new Regex(@"\[[^\]]*\]|(-)");
    var group1Caps = new StringCollection();
     
    string replaced = myRegex.Replace(s1, delegate(Match m) {
    if (m.Groups[1].Value == "") return m.Groups[0].Value;
    else return "SPLIT_HERE";
    });
    
    string[] splits = Regex.Split(replaced,"SPLIT_HERE");
    foreach (string split in splits) Console.WriteLine(split);
     
    Console.WriteLine("\nPress Any Key to Exit.");
    Console.ReadKey();
     
    } // END Main
    } // END Program
     
