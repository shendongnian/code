    public class MyBlock : IDisposable {
        private readonly TextWriter _writer;
        public MyBlock(TextWriter writer) {
	        _writer = writer;
            _writer.WriteLine("BEGIN");
        }
        public void Dispose() {
            _writer.WriteLine("END");
        }
    }
    @{ 
        var content =Html.Content(
            @<text>
                @using (new MyBlock(__razor_template_writer)) {
                    @: some content 2
                }
            <text>
        );
    }
    @content
