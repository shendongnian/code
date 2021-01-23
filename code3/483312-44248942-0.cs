    using System;
    using System.Collections.Generic;
    
      public class Ntuple{
        /*parent class
        has an array of coordinates
        coordinate-wise addition method
        greater or less than in dictionary order
        */
        public List<double> Coords = new List<double>();
        public int Dimension;
    
        public Ntuple(List<double> Input){
          Coords=Input;
          Dimension=Input.Count;
        }//instance constructor
    
        public Ntuple(){
        }//empty constructor, because something with the + overload?
    
    
       public static Ntuple operator +(Ntuple t1, Ntuple t2)
       {
         //if dimensions don't match, throw error
         List<double> temp = new List<double>();
         for (int i=0; i<t1.Dimension; i++){
           temp.Add(t1.Coords[i]+t2.Coords[i]);
         }
         Ntuple sum = new Ntuple(temp);
         return sum;
       }//operator overload +
    
       public static bool operator >(Ntuple one, Ntuple other){
         //dictionary order
         for (int i=0; i<one.Dimension; i++){
           if (one.Coords[i]>other.Coords[i]) {return true;}
         }
         return false;
       }
       public static bool operator <(Ntuple one, Ntuple other){
         //dictionary order
         for (int i=0; i<one.Dimension; i++){
           if (one.Coords[i]<other.Coords[i]) {return true;}
         }
         return false;
       }
    
      }//ntuple parent class
    
    
    
      public class OrderedPair: Ntuple{
        /*
        has additional method PolarCoords, &c
        */
        public OrderedPair(List<double> Coords) : base(Coords){}
        //instance constructor
        public OrderedPair(Ntuple toCopy){
          this.Coords=toCopy.Coords;
          this.Dimension=toCopy.Dimension;
        }
    
      }//orderedpair
    
      public class TestProgram{
        public static void Main(){
          List<double> oneCoords=new List<double>(){1,2};
          List<double> otherCoords= new List<double>(){2,3};
    
    
          OrderedPair one = new OrderedPair(oneCoords);
          OrderedPair another = new OrderedPair(otherCoords);
          OrderedPair sum1 = new OrderedPair(one + another);
    
    
          Console.WriteLine(one.Coords[0].ToString()+one.Coords[1].ToString());
          Console.WriteLine(sum1.Coords[0].ToString()+sum1.Coords[1].ToString());
    
          bool test = one > another;
          Console.WriteLine(test);
          bool test2 = one < another;
          Console.WriteLine(test2);
        }
      }
    
    
    }//namespace ntuples
