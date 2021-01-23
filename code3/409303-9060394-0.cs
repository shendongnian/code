void beatportTest_GetDataCompleted(object sender, DownloadStringCompletedEventArgs e)
{
   try
   {
      Genres data = JsonConvert.DeserializeObject<Genres>(e.Result);
      // for-each loop to display data
   }
   catch(Exception ex)
   {
   }
}
</pre>
