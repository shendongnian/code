    interface IContentItem {
      void Accept(IContentVisitor visitor);
    }
    class Photo : IPhoto {
      void Accept(IContentVisitor visitor) { visitor.Visit(this); }
    }
    
    interface IContentVisitor<T>{
      T Visit(IPhoto photo);
      T Visit(IEntity entity);
    }
    
    class ContentVisitor : IContentVisitor<string>{
      string Visit(IPhoto photo) { return "<p>A normal thing</p>"; }
      string Visit(IEntity entity) { return "<p>A normal thing</p>"; }
    }
    
    var visitor = new ContentVisitor();
    @foreach (var result in Model.Result)
    {
    
        if(result is IContentItem)
           result.Accept(visitor);
        else //assuming result is IEntity
           visitor.Visit(result);
    }
