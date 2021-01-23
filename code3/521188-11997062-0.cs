    public enum Collapse
    {
      None                      = 0 ,
      EmptyAndWhitespace        = 1 ,
      NullAndWhitespace         = 2 ,
      NullAndEmpty              = 3 ,
      NullAndEmptyAndWhitespace = 4 ,
    }
    
    public class MySpecialStringComparerDecorator : StringComparer
    {
      const   string         COLLAPSED_VALUE = "" ;
      private StringComparer instance ;
      private Collapse     rule     ;
      
      public MySpecialStringComparerDecorator( StringComparer comparer , Collapse equivalencyRule )
      {
        if ( comparer == null                                  ) throw new ArgumentNullException("comparer") ;
        if ( !Enum.IsDefined(typeof(Collapse),equivalencyRule) ) throw new ArgumentOutOfRangeException("equivalencyRule") ;
        
        this.instance = comparer ;
        this.rule     = equivalencyRule ;
        
        return ;
      }
      
      private string CollapseAccordingToRule( string s )
        {
            string collapsed = s ;
            if ( rule != Collapse.None )
            {
                if ( string.IsNullOrWhiteSpace(s) )
                {
                    bool isNull  = ( s == null ? true : false ) ;
                    bool isEmpty = ( s == ""   ? true : false ) ;
                    bool isWS    = !isNull && !isEmpty ;
                    switch ( rule )
                    {
                        case Collapse.EmptyAndWhitespace        : if ( isNull||isWS          ) collapsed = COLLAPSED_VALUE ; break ;
                        case Collapse.NullAndEmpty              : if ( isNull||isEmpty       ) collapsed = COLLAPSED_VALUE ; break ;
                        case Collapse.NullAndEmptyAndWhitespace : if ( isNull||isEmpty||isWS ) collapsed = COLLAPSED_VALUE ; break ;
                        case Collapse.NullAndWhitespace         : if ( isNull||isWS          ) collapsed = COLLAPSED_VALUE ; break ;
                        default                                 : throw new InvalidOperationException() ;
                    }
                }
            }
            return collapsed ;
        }
      
      public override int Compare( string x , string y )
      {
        string a     = CollapseAccordingToRule(x) ;
        string b     = CollapseAccordingToRule(y) ;
        int    value = instance.Compare(a,b);
        return value ;
      }
      
      public override bool Equals( string x , string y )
      {
        string a     = CollapseAccordingToRule(x) ;
        string b     = CollapseAccordingToRule(y) ;
        bool   value = instance.Equals(a,b) ;
        return value ;
      }
      
      public override int GetHashCode( string obj )
      {
        string s     = CollapseAccordingToRule(obj) ;
        int    value = instance.GetHashCode( s ) ;
        return value ;
      }
      
    }
