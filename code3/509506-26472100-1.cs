    public async Task<int> PostPerson(Models.Person person)
    {
      //call to the generic post 
      var response = await this.Post("People", person);
      
      //get the new id from Uri api/People/6 <-- this is generated in the response after successful post
      var st =  response.Headers.Location.Segments[3];
      //do whatever you want with the id
      return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<int>(st) : 0;
    }
