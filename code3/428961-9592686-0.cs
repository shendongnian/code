    public class BolaInfo : INotifyPropertyChanged{
       private double _angulo;
       private double _raio;
       private double? _velocityX;
       public BolaInfo(double initRaio)
       {
          var rand = new Random();
          //just do initialization of class members
          this.angulo = (double)(rand.Next(0, 360));
          this.raio = initRaio;
       }
       public double VelocityX
       {
         get{
            if( _velocityX == null ){
               _velocityX = Math.Cos(this.angulo * Math.PI / 180) + raio;
            }
            return _velocityX.Value;
         }
       }
       //writable property needs a setter
       public double Raio{
         get{ 
           return _raio;
         }
         set{
           if( _raio == value ) return;
           _raio = value;
           _velocityX = null;
           RaisePropertyChanged("Raio");
           RaisePropertyChanged("VelocityX");
         } 
       }
       private void RaisePropertyChanged(String propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    } 
