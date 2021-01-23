    public class People 
    { 
        public string BetterFoot; 
 
        public override bool Equals(object obj)
        { 
            var o = obj as People;
            if (o == null) return false;
            return (this.BetterFoot = o.BetterFoot); 
    } 
 
    public class LeftiesOrRighties: People 
    { 
        public string BetterHand; 
 
        public override bool Equals(object obj) 
        { 
            var o = obj as LeftiesOrRighties; 
            if ( o == null) return base.Equals(obj);
            return (this.BetterFoot = o.BetterFoot) && (this.BetterHand = o.BetterHand) 
        } 
    } 
 
    public class Ambidextrous: People
    { 
        public string FavoriteHand; 
    } 
