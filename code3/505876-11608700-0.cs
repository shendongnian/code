    internal class Content {
        internal void SetMaster(Master master) {this.master = master; }
        //...
    }
    internal class Master {
        internal void SetContent(Content content) {
            if(content == null) throw new ArgumentNullException("content");
            // maybe handle double-calls...
            this.content = content;
            content.SetMaster(this);
        }
    }
    ...
    Master M = new Master();
    M.SetContent(new Content());
