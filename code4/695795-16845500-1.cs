using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.ML.SVM;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Train;
using Encog.ML.SVM.Training;
namespace MultiClassSVM
{
    class Program
    {
        /// <summary>
        /// Input for function, normalized to 0 to 1.
        /// </summary>
        public static double[][] ClassificationInput = {
            new[] {0.0, 0.0},
            new[] {0.1, 0.0},
            new[] {0.2, 0.0},
            new[] {0.3, 0.0},
            new[] {0.4, 0.5},
            new[] {0.5, 0.5},
            new[] {0.6, 0.5},
            new[] {0.7, 0.5},
            new[] {0.8, 0.5},
            new[] {0.9, 0.5}
            };
        /// <summary>
        /// Ideal output, these are class numbers, a total of four classes here (0,1,2,3).
        /// DO NOT USE FRACTIONAL CLASSES (i.e. there is no class 1.5)
        /// </summary>
        public static double[][] ClassificationIdeal = {
            new[] {0.0},
            new[] {0.0},
            new[] {0.0},
            new[] {0.0},
            new[] {1.0},
            new[] {1.0},
            new[] {2.0},
            new[] {2.0},
            new[] {3.0},
            new[] {3.0}
        };
        static void Main(string[] args)
        {
            // create a neural network, without using a factory
            var svm = new SupportVectorMachine(2, false); // 2 input, & false for classification
            // create training data
            IMLDataSet trainingSet = new BasicMLDataSet(ClassificationInput, ClassificationIdeal);
            // train the SVM
            IMLTrain train = new SVMSearchTrain(svm, trainingSet);
            int epoch = 1;
            do
            {
                train.Iteration();
                Console.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                epoch++;
            } while (train.Error > 0.01);
            // test the SVM
            Console.WriteLine(@"SVM Results:");
            foreach (IMLDataPair pair in trainingSet)
            {
                IMLData output = svm.Compute(pair.Input);
                Console.WriteLine(pair.Input[0]
                                  + @", actual=" + output[0] + @",ideal=" + pair.Ideal[0]);
            }
            Console.WriteLine("Done");
        }
    }
}
