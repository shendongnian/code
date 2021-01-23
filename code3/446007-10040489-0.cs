public class ResponseAttribute : Attribute { 
  public string PropertyName { get; set }
}
[ResponseAttribute ("CustomResponse")}
public class Question1 {
   public string CustomResponse;
}
via reflection
foreach(var question in questions) {
   var responseAttr = (ResponseAttribute) question.GetType().GetCustomAttributes(typeof(ResponseAttribute));
var questionResponse= question.GetType().GetProperty(responseAttr.PropertyName,question,null);
}
 
