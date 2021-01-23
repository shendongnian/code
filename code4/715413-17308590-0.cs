    using(TagLib.File tlFile = TagLib.File.Create(newFileName)){
        //tlFile.Tag.Performers = new []{translateDict[author]}; //doesn't work
        tlFile.Tag.Performers = null; //clearing out performers
        tlFile.Tag.Performers = new []{translateDict[author]}; //works now
	    tlFile.Save();
    }
