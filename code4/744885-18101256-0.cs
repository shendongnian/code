    static void Main()
    {
       FileStream fs = new FileStream("Scheduler.txt",FileMode.Open, FileAccess.Read);
       StreamReader filereader = new StreamReader(fs);
       string linevalue = "";
       ArrayList items = new ArrayList();
       while ((linevalue = filereader.ReadLine()) != null)
       {
           //linevalue = filereader.ReadLine();
           items.Add(linevalue);
       }
       filereader.Close();
       items.Sort();
       IEnumerator myEnumerator = items.GetEnumerator();
       while (myEnumerator.MoveNext())
       {
           Console.WriteLine(myEnumerator.Current);
       }
    }
