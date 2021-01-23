    void TestReturnValue()
    {
        using (var db = new YourDBContext())
        {
            var result = new System.Data.Objects.ObjectParameter("Result", 0);
            Console.WriteLine("SP returned {0}", db.TestReturnValue(123, result));
            Console.WriteLine("Output param {0}", result.Value);
        }
    }
