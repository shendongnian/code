     List<int> list ; // Assign with your session int list values
                List<string> l2 = list.ConvertAll<string>(delegate(int i) { return i.ToString(); });
                string query = "Select Proizvodi.ime, TipProizvoda.tip, Proizvodi.dimenzije, Proizvodi.cijena from Proizvod LEFT JOIN TipProizvoda On Proizvod.tip=TipProizvoda.id_t WHERE Proizvod.id_p IN (";
                query = query + string.Join(",", l2.ToArray()) + ")";
                SqlDataAdapter da = new SqlDataAdapter(query, Conn);
