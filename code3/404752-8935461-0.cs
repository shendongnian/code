    @model Entity
    @if (Model is INamedEntity)
    {
      @{ Html.RenderPartial("NamedEntityFields", (INamedEntity)Model); }
    }
    @if (Model is IOrderedEntity)
    {
      @{ Html.RenderPartial("OrderedEntityFields", (IOrderedEntity)Model); }
    }
