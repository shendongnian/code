            DataContractJsonSerializer objseria = new DataContractJsonSerializer(typeof(StudentDetails));
            MemoryStream mem = new MemoryStream();
            objseria.WriteObject(mem, stu);
            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString("http://localhost:62013/Service1.svc/ADDStudent", "POST", data);
