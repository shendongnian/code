    public void CallToMethodInOtherClass(List<int> list)
    {
       lock(locker)//same as in the question, different locker to that used elsewhere.
       {
         int i = list.Count;
         if(i > 93)
           Console.WriteLine(list[93]);
       }
    }
