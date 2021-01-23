    using (BinaryReader br = new BinaryReader(File.Open(fileName,   
    FileMode.Open))) {
				//int pos = 0;
				//int length = (int)br.BaseStream.Length;
				while (br.BaseStream.Position != br.BaseStream.Length) {
					string nume = br.ReadString ();
					string prenume = br.ReadString ();
					Persoana p = new Persoana (nume, prenume);
					myArrayList.Add (p);
					Console.WriteLine ("ADAUGAT XXX: "+ p.ToString());
					//pos++;
				}
			}
