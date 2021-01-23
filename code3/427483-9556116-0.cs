    public partial class PreTextTemplate : PreTextTemplateBase
    {
        public virtual string TransformText()
        {
            this.Write("some text");
            return this.GenerationEnvironment.ToString();
        }
    }
    public class PreTextTemplateBase
    {
        protected StringBuilder GenerationEnvironment { get { … } set { … } }
        public void Write(string textToAppend)
        {
            // code to write to GenerationEnvironment
        }
    }
