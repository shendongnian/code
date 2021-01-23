    public class LogItem
    { 
        ....
        public static LogItem operator ++(LogItem item) 
        {
           item.visitTimes ++;
           return item;
        }
    }
