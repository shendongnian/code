     List<Detail> _source = new List<Detail>();
                for (int i = 0; i < 10; i++)
                {
                    _source.Add(new Detail
                    {
                        FirstName = "Name_" + i,
                        LastName = "Surname_" + i,
                        Section = "Section_" + i
                    });
                }
    
                dataGridView1.DataSource = _source;
