    [TestClass]
    public class SomeServiceTests
    {
        [TestMethod]
        public void service_triggers_msg_event_when_a_complete_message_is_recieved()
        {
            var client = Substitute.For<INetworkClient>();
            var expected = "Hello world";
            var e = new ReceivedEventArgs(Encoding.ASCII.GetBytes(expected + "\n"));
            var actual = "";
            var sut = new SomeService(client);
            sut.MessageReceived += (sender, args) => actual = args.Message;
            client.BufferReceived += Raise.EventWith(e);
            actual.Should().Be(expected);
        }
        [TestMethod]
        public void Send_should_invoke_Send_of_networkclient()
        {
            var client = Substitute.For<INetworkClient>();
            var msg = "Hello world";
            var sut = new SomeService(client);
            sut.Send(msg);
            client.Received().Send(Arg.Any<byte[]>(), 0, msg.Length + 1);
        }
        [TestMethod]
        public void Send_is_not_allowed_while_disconnected()
        {
            var client = Substitute.For<INetworkClient>();
            var msg = "Hello world";
            var sut = new SomeService(client);
            client.Disconnected += Raise.Event();
            Action actual = () => sut.Send(msg);
            actual.ShouldThrow<InvalidOperationException>();
        }
    }
