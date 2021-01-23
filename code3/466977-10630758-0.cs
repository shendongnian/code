    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace MutiItemDict
    {
        class MultiDict<TKey, TValue>  // no (collection) base class
        {
            private Dictionary<TKey, List<TValue>> _data = new Dictionary<TKey, List<TValue>>();
    
            public void Add(TKey k, TValue v)
            {
                // can be a optimized a little with TryGetValue, this is for clarity
                if (_data.ContainsKey(k))
                    _data[k].Add(v);
                else
                    _data.Add(k, new List<TValue>() { v });
            }
    
            public List<TValue> GetValues(TKey key)
            {
                if (_data.ContainsKey(key))
                    return _data[key];
                else
                    return new List<TValue>();
            }
        }
    
        class BookItem
        {
            public BookItem()
            {
                Authors = new List<string>();
                Editors = new List<string>();
            }
    
            public int? Year { get; set; }
            public string Title { get; set; }
            public string Book { get; set; }
            public List<string> Authors { get; private set; }
            public List<string> Editors { get; private set; }
            public string Publisher { get; set; }
            public string City { get; set; }
            public int? StartPage { get; set; }
            public int? EndPage { get; set; }
            public int? Issue { get; set; }
            public string Conference { get; set; }
            public string Journal { get; set; }
            public int? Volume { get; set; }
    
            internal void AddPropertyByText(string line)
            {
                string keyword = GetKeyWord(line);
                string data = GetData(line);
                AddData(keyword, data);
            }
    
            private void AddData(string keyword, string data)
            {
                if (keyword == null)
                    return;
    
                // Map the Keywords to the properties (can be done in a more generic way by reflection)
                switch (keyword)
                {
                    case "Year":
                        this.Year = int.Parse(data);
                        break;
                    case "Title":
                        this.Title = data;
                        break;
                    case "Book":
                        this.Book = data;
                        break;
                    case "Author":
                        this.Authors.Add(data);
                        break;
                    case "Editor":
                        this.Editors.Add(data);
                        break;
                    case "Publisher":
                        this.Publisher = data;
                        break;
                    case "City":
                        this.City = data;
                        break;
                    case "Journal":
                        this.Journal = data;
                        break;
                    case "Volume":
                        this.Volume = int.Parse(data);
                        break;
                    case "Pages":
                        this.StartPage = GetStartPage(data);
                        this.EndPage = GetEndPage(data);
                        break;
                    case "Issue":
                        this.Issue = int.Parse(data);
                        break;
                    case "Conference":
                        this.Conference = data;
                        break;
                }
            }
    
            private int GetStartPage(string data)
            {
                string[] pages = data.Split('-');
                return int.Parse(pages[0]);
            }
    
            private int GetEndPage(string data)
            {
                string[] pages = data.Split('-');
                return int.Parse(pages[1]);
            }
    
            private string GetKeyWord(string line)
            {
                string[] words = line.Split(' ');
                if (words.Length == 0)
                    return null;
                else
                    return words[0];
            }
    
            private string GetData(string line)
            {
                string[] words = line.Split(' ');
                if (words.Length < 2)
                    return null;
                else
                    return line.Substring(words[0].Length+1);
            }
        }
    
        class Program
        {
            public static BookItem ReadBookItem(StreamReader streamReader)
            {
                string line = streamReader.ReadLine();
                if (line == null)
                    return null;
    
                BookItem book = new BookItem();
                while (line != "End")
                {
                    book.AddPropertyByText(line);
                    line = streamReader.ReadLine();
                }
                return book;
            }
    
            public static List<BookItem> ReadBooks(string fileName)
            {
                List<BookItem> books = new List<BookItem>();
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    BookItem book;
                    while ((book = ReadBookItem(streamReader)) != null)
                    {
                        books.Add(book);
                    }
                }
                return books;
            }
    
            static void Main(string[] args)
            {
                string fileName = "../../Data.txt";
                List<BookItem> bookList = ReadBooks(fileName);
    
                MultiDict<string, BookItem> booksByAutor = new MultiDict<string, BookItem>();
                bookList.ForEach(bk =>
                        bk.Authors.ForEach(autor => booksByAutor.Add(autor, bk))
                    );
    
                string author = "Bond, james";
                Console.WriteLine("Books by: " + author);
                foreach (BookItem book in booksByAutor.GetValues(author))
                {
                    Console.WriteLine("    Title : " + book.Title);
                }
    
                Console.WriteLine("");
                Console.WriteLine("Click to continue");
                Console.ReadKey();
            }
        }
    }
