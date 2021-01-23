    /// <summary>
    /// Contains most values for the rel attribute on an HTML anchor hyperlink elemement.
    /// </summary>
    public static class HyperlinkRelationships
    {
        /// <summary>
        /// Designates substitute versions for the document in which the link occurs. When used together with the lang attribute, it implies a translated version of the document. When used together with the media attribute, it implies a version designed for a different medium (or media).
        /// </summary>
        public const string AlternateRelationship = "alternate";
        /// <summary>
        /// Refers to a document serving as an appendix in a collection of documents.
        /// </summary>
        public const string AppendixRelationship = "appendix";
        /// <summary>
        /// Refers to an external style sheet. See the section on external style sheets for details. This is used together with the link type "Alternate" for user-selectable alternate style sheets.
        /// </summary>
        public const string AuthorRelationship = "author";
        /// <summary>
        /// Refers to a bookmark. A bookmark is a link to a key entry point within an extended document. The title attribute may be used, for example, to label the bookmark. Note that several bookmarks may be defined in each document.
        /// </summary>
        public const string BookmarkRelationship = "bookmark";
        /// <summary>
        /// Refers to a document serving as a chapter in a collection of documents.
        /// </summary>
        public const string ChapterRelationship = "chapter";
        /// <summary>
        /// Refers to a copyright statement for the current document.
        /// </summary>
        public const string CopyrightRelationship = "copyright";
        /// <summary>
        /// Refers to a document serving as a table of contents. Some user agents also support the synonym ToC (from "Table of Contents").
        /// </summary>
        public const string ContentsRelationship = "contents";
        /// <summary>
        /// Refers to a document offering help (more information, links to other sources information, etc.)
        /// </summary>
        public const string HelpRelationship = "help";
        /// <summary>
        /// Links to copyright information for the document.
        /// </summary>
        public const string LicenseRelationship = "license";
        /// <summary>
        /// Refers to a document providing a glossary of terms that pertain to the current document.
        /// </summary>
        public const string GlossaryRelationship = "glossary";
        /// <summary>
        /// Refers to a document providing an index for the current document.
        /// </summary>
        public const string IndexRelationship = "index";
        /// <summary>
        /// Refers to the next document in a linear sequence of documents. User agents may choose to preload the "next" document, to reduce the perceived load time.
        /// </summary>        
        public const string NextRelationship = "next";
        /// <summary>
        /// Links to an unendorsed document, like a paid link. ("nofollow" is used by Google, to specify that the Google search spider should not follow that link)
        /// </summary>
        public const string NoFollowRelationship = "nofollow";
        /// <summary>
        /// Specifies that the browser should not send a HTTP referer header if the user follows the hyperlink.
        /// </summary>
        public const string NoReferrerRelationship = "noreferrer";
        /// <summary>
        /// Specifies that the target document should be cached.
        /// </summary>
        public const string PrefetchRelationship = "prefetch";
        /// <summary>
        /// Refers to the previous document in an ordered series of documents. Some user agents also support the synonym "Previous".
        /// </summary>
        public const string PrevRelationship = "prev";
        /// <summary>
        /// Links to a search tool for the document.
        /// </summary>
        public const string SearchRelationship = "search";
        /// <summary>
        /// Refers to a document serving as a section in a collection of documents.
        /// </summary>
        public const string SectionRelationship = "section";
        /// <summary>
        /// Refers to a document serving as a subsection in a collection of documents.
        /// </summary>
        public const string SubsectionRelationship = "subsection";
        /// <summary>
        /// Refers to the first document in a collection of documents. This link type tells search engines which document is considered by the author to be the starting point of the collection.
        /// </summary>
        public const string StartRelationship = "start";
        /// <summary>
        /// Refers to an external style sheet. See the section on external style sheets for details. This is used together with the link type "Alternate" for user-selectable alternate style sheets.
        /// </summary>
        public const string StylesheetRelationship = "stylesheet";
        /// <summary>
        /// A tag (keyword) for the current document.
        /// </summary>
        public const string TagRelationship = "tag";
    }
