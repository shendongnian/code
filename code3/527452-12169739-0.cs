    /* Application counts the number of occurrences of each word in a string
       and stores them in a generic sorted dictionary. */
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    public class SortedDictionaryTest
    {
       public static void Main( string[] args )
       {
          // create sorted dictionary
          SortedDictionary< string, int > dictionary = CollectWords();
    
          // display sorted dictionary content
          DisplayDictionary( dictionary );
       } 
    
       // create sorted dictionary 
       private static SortedDictionary< string, int > CollectWords()
       {
          // create a new sorted dictionary
          SortedDictionary< string, int > dictionary =
             new SortedDictionary< string, int >();
    
          Console.WriteLine( "Enter a string: " ); // prompt for user input
          string input = Console.ReadLine(); 
    
          // split input text into tokens
          string[] words = Regex.Split( input, @"\s+" );
    
          // processing input words
          foreach ( var word in words )
          {
             string wordKey = word.ToLower(); // get word in lowercase
    
             // if the dictionary contains the word
             if ( dictionary.ContainsKey( wordKey ) )
             {
                ++dictionary[ wordKey ];
             } 
             else
                // add new word with a count of 1 to the dictionary
                dictionary.Add( wordKey, 1 );
          } 
    
          return dictionary;
       } 
    
       // display dictionary content
       private static void DisplayDictionary< K, V >(
          SortedDictionary< K, V > dictionary )
       {
          Console.WriteLine( "\nSorted dictionary contains:\n{0,-12}{1,-12}",
             "Key:", "Value:" );
    
          /* generate output for each key in the sorted dictionary
            by iterating through the Keys property with a foreach statement*/
          foreach ( K key in dictionary.Keys )
             Console.WriteLine( "{0,- 12}{1,-12}", key, dictionary[ key ] );
    
          Console.WriteLine( "\nsize: {0}", dictionary.Count );
       } 
    } 
