            var sampleOne = new DataTable();
            var sampleTwo = new DataTable();
            // TODO : I assume these two table have the common column "ZipCode".
            // TODO : Add your sample data here!
            var matchingRows = from s1 in sampleOne.AsEnumerable()
                               join s2 in sampleTwo.AsEnumerable() on s1.Field<string>("ZipCode") equals s2.Field<string>("ZipCode")
                               select s1;
            foreach (var row in matchingRows)
            {
                // Do your stuff here !
            }
