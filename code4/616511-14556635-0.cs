    using System.IO;//don't forget to reference the IO package
	    TextWriter writer = new StreamWriter("class1.txt");
            try
            {
               string Name01 = NameBox.Text;
               string Name02 =FamilyNameBox.Text;
               string Name03 = PhoneBox.Text;
               string Informtion = Name01 + Name02 + Name03;        
		       writer.WriteLine(Informtion);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                writer.Close();
                writer.Dispose();
            }
