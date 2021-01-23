		private void Test(){
			byte[] Bytes = File.ReadAllBytes("json.txt");
			string Json = Encoding.ASCII.GetString(Bytes);
			Response JsonResponse = JsonConvert.DeserializeObject<Response>(Json);
			if (JsonResponse != null){
				if (JsonResponse.response != null){
					foreach(Document Doc in JsonResponse.response.docs){
						if (Doc.id == "2f7661ae3c7a42dd9f2eb1946262cd24"){
							Doc.name = "David";
							Doc.email = "david@email.com";
						}
					}
					string JsonMod = JsonConvert.SerializeObject(JsonResponse, Formatting.Indented);
					BinaryWriter Writer = new BinaryWriter(File.Create("JsonMod.txt"));
					Writer.Write(Encoding.ASCII.GetBytes(JsonMod));
					Writer.Close();
					Writer.Dispose();
				}
			}
		}
