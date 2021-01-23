    object result = JsonConvert.DeserializeObject<ExampleClass>(e.Result);
    //                                            ^^^^^^^^^^^^
    //                                                This
        try{
            PropertyInfo pi = result.GetType().GetProperty("success");
            bool success = (bool)(pi.GetValue(result, null));
            Console.Write(success); // True
        } 
        catch (Exception f) {
            Console.Write(f);
        }
