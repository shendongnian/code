    public class MockSocket : ISocket
    {
         private byte[] testData;
         public void SetTestData(byte[] data)
         {
             testData = data;
         }
         public byte[] Receive(int numberOfBytes)
         {
             return testData;
         }
         // you need to implement all members of ISocket ofcourse...
    }
