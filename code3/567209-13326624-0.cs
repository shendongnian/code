// Producing thread
for (int i=0; i&lt;1000000; i++)
    blockingCollection.Add(myObject);
// Consuming threads
while (true)
{
      var myObject = blockingCollection.Take();
      db4oSession.Store(myObject); // or write it to the files or whathever
}
