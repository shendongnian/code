    private MouseTimer mouseTimer = new  
    MouseTimer(getMouseDoubleClickInterval(),taskPerformer);
     
     //The DebugClock helps me to see how long a process that I have programmed takes from 
    start to finish.
         private DebugClock clock = new DebugClock();
    
     //Constructors
     public MyMouseAdapter(){
          super();
     }
     
     
    @Override
    public void mouseClicked(MouseEvent e){ 
         event = e;
         if(e.getClickCount() == 1){
              mouseTimer.setInitialDelay(mouseDoubleClickInterval);
              mouseTimer.start();
         }
         mouseTimer.setNumOfClicks();
    }
    
    public void mouseSingleClicked(MouseEvent e){
         p("Mouse was SingleClicked!!!\n");
    }
    public void mouseDoubleClicked(MouseEvent e){
         p("Mouse was DoubleClicked!!!\n");
    }
    @Override
    public void mouseMoved(MouseEvent e){
         event = e;
         mouseTimer.resetNumOfClicks();
         mouseTimer.stop();
    }
    
    //Setters and Getters for MouseAdapter
    public Integer getMouseDoubleClickInterval(){
          return this.mouseDoubleClickInterval;
    }
    
    
    
        //Timer Classes
        private class MouseTimer extends Timer{
 
         //Constructors
         public MouseTimer(int delay, ActionListener taskPerformer){
              super(delay,taskPerformer);
         }
         
         //Instance variables
         private int numOfClicks = 0;
                   
          //Setters and Getters
          public int getNumOfClicks(){
               return this.numOfClicks;
          }
          public void setNumOfClicks(){
               this.numOfClicks++;
          }
          public void resetNumOfClicks(){
               this.numOfClicks = 0;
          }
        }
        //Basic Printing Classes
        private void p(String message){
         System.out.print(message);
        }
    }
    class DebugClock{
         private long startTime = 0;
         private long endTime = 0;
     
         //Setters and Getters
         public long getStartTime(){
              return this.startTime;
         }
         public void setStartTime(long start){
              this.startTime = start;
         }
         public long getEndTime(){
              return this.endTime;
         }
         public void setEndTime(long end){
              this.endTime = end;
         }
     
         //Constructors
         public DebugClock(){
          
         }
     
         //Methods
         public float getTimeInMilliSeconds(){
              float seconds = (this.endTime - this.startTime);
              return seconds;
         }
    }
