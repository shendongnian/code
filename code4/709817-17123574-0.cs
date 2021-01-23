      static void Main(string[] args)
      {
       enum Days { Sat, Sun, Mon, Tue, Wed, Thu, Fri };
        Array arr = Enum.GetValues(typeof(Days));
        List<string> lstDays = new List<string>(arr.Length);
        for (int i = 0; i < arr.Length; i++)
        {
            lstDays.Add(arr.GetValue(i).ToString());
        }
      }
