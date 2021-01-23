    var BeachDetail =  from Personal in dc.t_return_to_beaches
                       where Personal.emo_number == EmoNumber
                       select new 
                           {
                             Col1 = personal.Col1,
                             Col2 = personal.Col2,
                             Col3 = personal.Col3,                         
                             ....................
                             ....................
                             weight = String.Format("{0:0.00}", personal.Weight),
                             value = String.Format("{0:0.00}", personal.Value),
                           };
