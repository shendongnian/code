    public enum ChainType
    {
        none,
        unknown,
        horizontal,
        vertical,
        centerCross,
        leftTopCornerCross,
        rightTopCornerCross,
        leftBottomCornerCross,
        rightBottomCornerCross
    }
    public class aClass{
        ChainType chainType = ChainType.horizontal;
        someMethod(){
            if(chainType == ChainType.horizontal){..} 
        }
    }
