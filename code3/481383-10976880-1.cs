    string[] StrInputNumber = { "34556#%42%$23$%^*&sdfsfr", "asdf!\"§$%&/()=?*+~#'", "34556#%42%$23$%^*&בלה בלה", "öäü!\"§$%&/()=?*+~#'" };
    Regex ASCIILettersOnly = new Regex(@"^[\P{L}A-Za-z]*$");
    foreach (String item in StrInputNumber) {
    
        if (ASCIILettersOnly.IsMatch(item)) {
            Console.WriteLine(item + " ==> Contains only ASCII letters");
        }
        else {
            Console.WriteLine(item + " ==> Contains non ASCII letters");
    
        }
    }
