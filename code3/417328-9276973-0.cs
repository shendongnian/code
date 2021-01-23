    var q = from a in db.GetTable<Medlemmer>()
            from g in db.Get_grader(Convert.ToInt32(a.Skif))
               where a.Aktiv == true
               orderby a.Navn
               select new
                   {
                     g.Grad,
                     Skif = a.Skif,
                     Navn = a.Navn,
                     Mellemnavn = a.Mellemnavn,
                     Efternavn = a.Efternavn,
                     Adresse = a.Adresse,
                     Telefon = a.Telefon,
                     Mobil = a.Mobil,
                     PostNr = a.PostNr,
                     town = a.town,
                     mail = a.mail,
                     Picture = a.Picture 
                   };
