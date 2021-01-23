            // my pretend dataset
            List<string> fields = new List<string>();
            // my 'columns'
            fields.Add("this_thing");
            fields.Add("that_thing");
            fields.Add("the_other");
            dynamic exo = new System.Dynamic.ExpandoObject();
            foreach (string field in fields)
            {
                ((IDictionary<String, Object>)exo).Add(field, field + "_data");
            }
            // output - from Json.Net NuGet package
            textBox1.Text = Newtonsoft.Json.JsonConvert.SerializeObject(exo);
