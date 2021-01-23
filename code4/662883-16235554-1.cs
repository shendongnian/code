    private void SearchContactSuccess(HttpWebResponse response)
        {
 
            //Call base service method - to inspect the response and publish an event
            HandleServiceSearchSuccess<ContactDetailsPreview[]>(SearchContactDetailsCompleted, "contactDetailsPreviews", response);
            Stream receiveStream = response.GetResponseStream();
            Encoding encode = System.Text.Encoding.UTF8;
            StreamReader readStream = new StreamReader(receiveStream, encode);
            readStream.ReadLine();
        }
 
