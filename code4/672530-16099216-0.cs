    private Dictionary<string, string> _answers = new Dictionary<string, string>();
    public void StudentDetailInput()
    {
        const int startpoint = 2;
        string[] takeinput = new string[] {"FirstName", "Surname", "MiddleName", "StudentId", "Subject", "AddressLine1", "AddressLine2", "Town", "Postcode", "Telephone", "Email" };
        _answers.Clear();
        for (int x = 0; x < takeinput.Length; x++)
        {
            Console.Write(takeinput[x] + ": ");
            var answer = Console.ReadLine();
            _answers.Add(takeinput[x], answer);
        }
    }
