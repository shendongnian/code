    using (var outputStreamFile = new MemoryStream()) {
      var userId = m_userRepository.GetuserByLogin(this.User.Identity.Name).UserId;
      var streamWriter = new StreamWriter(outputStreamFile);
      streamWriter.WriteLine(m_kamikaze2Repository.GetGameById(gameId, userId).Result);
      outputStreamFile.Seek(0, SeekOrigin.Begin);
      zip.AddEntry("result_" + gameId, outputStreamFile);     
      zip.Save(outputStream);
    }
