    foreach (int i in form. listBox2.SelectedIndices)
                {
    				try
    				{
    					item = form.listBox2.Items[i].ToString();
    					groupid = item;
    
    					FacebookClient fbpost = new FacebookClient(AccessToken);
    					var imgstream = File.OpenRead(ImagePath);
    					dynamic res = fbpost.Post("/" + groupid + "/photos", new
    				   {
    					   message = Status,
    					   File = new FacebookMediaStream
    					   {    
    						   ContentType = "image/jpg",
    						   FileName = Path.GetFileName(ImagePath)
    					   }.SetValue(imgstream)
    
    				   });
    					result = true;
    				}
    				catch(exception excp)
    				{
    					//Do something with the exception
    				}
                }
