    ...
    
    [ ValidateInput(false)
    ]
    public class SomethingController : Controller
    {
      ...
      [ HttpPost
      ]
      public ActionResult ProcessSomething(SomeParameters Parameters, String Options)
      {
        ...
        String sProcessed = Parameters.Descriptor.ParamA + Parameters.Descriptor.ParamB;
        ...
        return this.Content
          ( String.Format
            ( "<result><processed>{0}</processed></result>"
            , sProcessed
            )
          , "text/xml"
          );
      }
      /// <summary>
      /// Description of a view model instance.
      /// </summary>
      [ XmlRoot("something")
      ]
      public class SomethingDescriptor
      {
        private String _ParamA = String.Empty;
        private String _ParamB = String.Empty;
        [ XmlElement("paramA")
        ]
        public String ParamA
        {
          set
          {
            this._ParamA = value;
          }
          get
          {
            return this._ParamA;
          }
        }
        [ XmlElement("paramB")
        ]
        public String ParamB
        {
          set
          {
            this._ParamB = value;
          }
          get
          {
            return this._ParamB;
          }
        }
      }
      /// <summary>
      /// View parameter deserializer.
      /// </summary>
      public class SomethingParameters
      {
        private SomethingDescriptor _Descriptor = new SomethingDescriptor();
        public SomethingDescriptor Descriptor
        {
          get
          {
            return this._Descriptor;
          }
        }
        public String Something
        {
          set
          {
            try
            {
              using (StringReader sR = new StringReader(value))
              {
                XmlSerializer xS = new XmlSerializer(typeof(SomethingDescriptor));
                this._Descriptor = xS.Deserialize(sR) as SomethingDescriptor;
              }
            }
            catch
            {
            }
          }
          get
          {
            return String.Empty;
          }
        }
      }
    }
