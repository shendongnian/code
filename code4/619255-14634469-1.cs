    using (var reader = new StreamReader(Txt_OrigemPath.Text) {
        reader.ReadLine();  // Skip first line (if this is what you want to do).
        while (!reader.EndOfStream) {
            string conteudo = reader.ReadLine();           
            string[] teste = conteudo.Split('*');
            var person = new Person {
                Matriculation = string[0],
                ID = string[1],
                IDDependent = string[2],
                Birthday = string[3]
            };
            persons.Add(person);
        }
    }
