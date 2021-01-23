     using System;
     
     [Flags]
     public enum AnimalCharacteristics : long
     {
         Tail = 1 << AnimalCharacteristicsBitPositions.Tail,
         Eyes = 1 << AnimalCharacteristicsBitPositions.Eyes,
         Furry = 1 << AnimalCharacteristicsBitPositions.Furry,
         Bipedal = 1 << AnimalCharacteristicsBitPositions.Bipedal
     }
     
     internal enum AnimalCharacteristicsBitPositions : int
     {
         Tail = 0,
         Eyes,
         Furry,
         Bipedal
     }
     
     public class Program
     {
         public static void Main()
         {
             var human = AnimalCharacteristics.Eyes | AnimalCharacteristics.Bipedal;
             var dog = AnimalCharacteristics.Eyes | AnimalCharacteristics.Tail | AnimalCharacteristics.Furry;
             
             Console.WriteLine($"Human: {human} ({(long)human})");
             Console.WriteLine($"Dog: {dog} ({(long)dog})");
         }
     }
