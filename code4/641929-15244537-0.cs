      public class EntityBase
      {
          public override string ToString()
          {
              StringBuilder sb = new StringBuilder();
              foreach ( var property in this.GetType().GetProperties() )
              {
                  sb.Append( property.GetValue( this, null ) );
              }
              return sb.ToString();
          } 
      }
      public class TheEntity : EntityBase
      {
          public string Foo { get; set; }
          public string Bar { get; set; }
      }
