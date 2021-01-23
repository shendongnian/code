    .aspx
    <asp:ListView ID="lvImages" runat="server">
       <ItemTemplate>
           <asp:Image ID="imgListImage" runat="server" ImageUrl='<% Eval("Url") %>' />
       </ItemTemplate>
    </asp:ListView>
    .aspx.cs
    class PhotoInfo {
        public string Url { get; set; }
    }
    
    ...
    var list = readerPhoto.ReadAll();
    var collection = list.select(i => new PhotoInfo {url = i });
    lvImages.DataSource = collection;
    lvImages.DataBind();
