    using (var reader = new StreamReader(Txt_OrigemPath.Text)) {
        reader.ReadLine();  // Skip first line (if this is what you want to do).
        while (!reader.EndOfStream) {
            string conteudo = reader.ReadLine();
            string[] teste = conteudo.Split('*');
            var person = new Person {
                Matriculation = teste[0],
                ID = teste[1],
                IDDependent = teste[2],
                Birthday = teste[3]
            };
            persons.Add(person);
        }
    }
