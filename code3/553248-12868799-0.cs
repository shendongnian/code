    public static class XmlExtensions
    {
       public static IEnumerable<XElement> CombineLikeElements(this IEnumerable<XElement> source, Func<XElement, object> groupSelector)
       {
          // used to record the newly combined elements
          List<XElement> priElements = new List<XElement>();
          
          // group the current xml nodes by the supplied groupSelector, and only
          // select the groups that have more than 1 elements.
          var groups = source.GroupBy(groupSelector).Where(grp => grp.Count() > 1);
          
          foreach(var grp in groups)
          {
             // get the first (primary) child element and use it as 
             // element that all the other sibling elements get combined with.
             var priElement = grp.First();
             
             // get all the sibling elements which will be combined
             // with the primary element.  Skipping the primary element.
             var sibElements = grp.Skip(1);
             
             // add all the sibling element's child nodes to the primary
             // element.
             priElement.Add(sibElements.Select(node => node.Elements()));
             
             // remove all of the sibling elements
             sibElements.Remove();
             
             // add the primary element to the return list
             priElements.Add(priElement);
          }
          
          // return the primary elements incase we want to do some further
          // combining of their descendents
          return priElements;
       }
    }
