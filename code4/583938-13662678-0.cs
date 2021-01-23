    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var compositeDiscountEvaluator = ConfigureEvaluator();
                var scienceBook = new TextBook
                                   {
                                       Date = DateTime.Now,
                                       Price = 100,
                                       Genres = new[] {TextBooksGenre.Math}
                                   };
                var textBook = new TextBook
                                   {
                                       Date = DateTime.Now,
                                       Price = 100,
                                       Genres = new[] {TextBooksGenre.Math, TextBooksGenre.Science}
                                   };
                var fictionBook = new ReadingBook
                            {
                                Date = DateTime.Now,
                                Price = 200,
                                Genres = new[] {ReadingBooksGenre.Fiction}
                            };
                var readingBook = new ReadingBook
                                      {
                                          Date = DateTime.Now,
                                          Price = 300,
                                          Genres = new[] {ReadingBooksGenre.Fiction, ReadingBooksGenre.NonFiction}
                                      };
                Console.WriteLine(compositeDiscountEvaluator.GetDiscount(scienceBook));
                Console.WriteLine(compositeDiscountEvaluator.GetDiscount(textBook));
                Console.WriteLine(compositeDiscountEvaluator.GetDiscount(fictionBook));
                Console.WriteLine(compositeDiscountEvaluator.GetDiscount(readingBook));
            }
            private static IDiscountEvaluator ConfigureEvaluator()
            {
                var evaluator = new CompositeDiscountEvaluator();
                evaluator.AddEvaluator(new ReadingBookDiscountEvaluator());
                evaluator.AddEvaluator(new TextBookDiscountEvaluator());
                return evaluator;
            }
        }
        class CompositeDiscountEvaluator : IDiscountEvaluator
        {
            private readonly ICollection<IDiscountEvaluator> evaluators;
            public CompositeDiscountEvaluator()
            {
                evaluators = new List<IDiscountEvaluator>();
            }
            public void AddEvaluator(IDiscountEvaluator evaluator)
            {
                evaluators.Add(evaluator);
            }
            public bool CanEvaluate<TGenre>(IBook<TGenre> book)
            {
                return evaluators.Any(e => e.CanEvaluate(book));
            }
            public int GetDiscount<TGenre>(IBook<TGenre> book)
            {
                if (!CanEvaluate(book))
                    throw new ArgumentException("No suitable evaluator");
                return evaluators.Where(e => e.CanEvaluate(book)).Select(e => e.GetDiscount(book)).Max();
            }
        }
        interface IDiscountEvaluator
        {
            bool CanEvaluate<TGenre>(IBook<TGenre> book);
            int GetDiscount<TGenre>(IBook<TGenre> book);
        }
        class ReadingBookDiscountEvaluator : IDiscountEvaluator
        {
            private readonly IDictionary<ReadingBooksGenre, int> discounts;
            public ReadingBookDiscountEvaluator()
            {
                discounts = new Dictionary<ReadingBooksGenre, int>
                                {
                                    {ReadingBooksGenre.Fiction, 3},
                                    {ReadingBooksGenre.NonFiction, 4}
                                };
            }
            public bool CanEvaluate<TGenre>(IBook<TGenre> book)
            {
                return book is ReadingBook;
            }
            public int GetDiscount<TGenre>(IBook<TGenre> book)
            {
                var readingBook = (ReadingBook) book;
                return readingBook.Genres.Select(g => discounts[g]).Max();
            }
        }
        class TextBookDiscountEvaluator : IDiscountEvaluator
        {
            private readonly IDictionary<TextBooksGenre, int> discounts;
            public TextBookDiscountEvaluator()
            {
                discounts = new Dictionary<TextBooksGenre, int>
                                {
                                    {TextBooksGenre.Math, 1},
                                    {TextBooksGenre.Science, 2}
                                };
            }
            public bool CanEvaluate<TGenre>(IBook<TGenre> book)
            {
                return book is TextBook;
            }
            public int GetDiscount<TGenre>(IBook<TGenre> book)
            {
                var textBook = (TextBook) book;
                return textBook.Genres.Select(g => discounts[g]).Max();
            }
        }
        interface IBook<TGenre>
        {
            int Price { get; set; }
            DateTime Date { get; set; }
            TGenre[] Genres { get; set; }
        }
        class ReadingBook : IBook<ReadingBooksGenre>
        {
            public int Price { get; set; }
            public DateTime Date { get; set; }
            public ReadingBooksGenre[] Genres { get; set; }
        }
        class TextBook : IBook<TextBooksGenre>
        {
            public int Price { get; set; }
            public DateTime Date { get; set; }
            public TextBooksGenre[] Genres { get; set; }
        }
        enum TextBooksGenre
        {
            Math,
            Science
        }
        public enum ReadingBooksGenre
        {
            Fiction,
            NonFiction
        }
    }
