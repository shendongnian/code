    /// <summary>
    /// A control that changes appearance when it is hovered over and triggers some effect when it is clicked
    /// </summary>
    public class EnigmaButton
    {
        /// <summary>
        /// The method signature for notification when a button is clicked
        /// </summary>
        /// <param name="sender">EnigmaButton that was clicked</param>
        public delegate void OnClickEvent(EnigmaButton sender);
        /// <summary>
        /// Types of textures used for Enigma Buttons
        /// </summary>
        public enum TextureType { Normal, Over, Press }
        #region Variables
	protected IVisualExposer m_ui;
	protected Rectangle m_bounds;
        IInputExposer m_input;
        bool m_over = false, m_press = false, m_wasPressed = false;
        Dictionary<TextureType, EnigmaResource<Texture2D>> m_textures;
        string m_text, m_name;
        EnigmaResource<SpriteFont> m_font;
        int m_minTextShadow, m_maxTextShadow;
        Color m_textTint;
        public event OnClickEvent OnClick;
        #endregion
        /// <summary>
        /// A control that changes appearance when it is hovered over and triggers some effect when it is clicked
        /// </summary>
        /// <param name="ui">Graphical assets</param>
        /// <param name="input">Input exposer for mouse input and XBox controller input</param>
        /// <param name="reader">XMLReader for the definition of the controller</param>
        /// <param name="pos">Bounds of the controller</param>
        public EnigmaButton(IVisualExposer ui, IInputExposer input, XmlReader reader, Rectangle pos)
        {
	    m_ui = ui;
	    m_bounds = pos;
            m_textures = new Dictionary<TextureType, EnigmaResource<Texture2D>>();
            m_input = input;
            Enabled = true;
            #region Reading
            string name;
            bool started = false, insideText = false;
            while (reader.Read())
            {
                if (reader.MoveToContent() == XmlNodeType.Element)
                {
                    name = reader.Name.ToLower();
                    if (name == "button")
                    {
                        if (started)
                            throw new Exception("Already started.");
                        started = true;
                        m_name = reader.GetAttribute("name") ?? string.Empty;
                    }
                    else if (!started)
                        throw new Exception("Not started");
                    else if (name == "text")
                    {
                        m_font = new EnigmaResource<SpriteFont>();
                        m_font.Filepath = reader.GetAttribute("font");
                        string minShadow = reader.GetAttribute("minShadow"), maxShadow = reader.GetAttribute("maxShadow");
                        m_minTextShadow = minShadow != null ? int.Parse(minShadow) : 0;
                        m_maxTextShadow = maxShadow != null ? int.Parse(maxShadow) : 2;
                        m_text = reader.GetAttribute("text") ?? string.Empty;
                        insideText = true;
                        m_textTint = Color.White;
                    }
                    else if (name == "bounds")
                    {
                        insideText = false;
                        m_bounds = new Rectangle(int.Parse(reader.GetAttribute("x")), int.Parse(reader.GetAttribute("y")),
                            int.Parse(reader.GetAttribute("width")), int.Parse(reader.GetAttribute("height")));
                    }
                    else if (name == "texture")
                    {
                        insideText = false;
                        TextureType texType = (TextureType)Enum.Parse(typeof(TextureType), reader.GetAttribute("type"));
                        if (m_textures.ContainsKey(texType))
                            throw new Exception("A texture of type '" + texType.ToString() + "' cannot  be registered twice");
                        EnigmaResource<Texture2D> res = new EnigmaResource<Texture2D>();
                        res.Filepath = reader.ReadString();
                        m_textures.Add(texType, res);
                    }
                    else if (name == "tint")
                    {
                        if (!insideText)
                            throw new Exception("Tints can only be for text");
                        float a, r, g, b;
                        string[] split = reader.ReadString().Split(',');
                        if (split.Length != 4)
                            throw new Exception("Colors must be RGBA");
                        r = float.Parse(split[0].Trim());
                        g = float.Parse(split[1].Trim());
                        b = float.Parse(split[2].Trim());
                        a = float.Parse(split[3].Trim());
                        m_textTint = new Color(r, g, b, a);
                    }
                }
            }
            #endregion
            if (!m_textures.ContainsKey(TextureType.Normal))
                throw new Exception("A button must have at least a '" + TextureType.Normal.ToString() + "' texture");
        }
        #region Methods
        public void Initialize()
        {
        }
        public void LoadContent()
        {
            EnigmaResource<Texture2D> res;
            for (int i = 0; i < m_textures.Count; i++)
            {
                res = m_textures[m_textures.ElementAt(i).Key];
                res.Resource = m_ui.Content.Load<Texture2D>(res.Filepath);
                m_textures[m_textures.ElementAt(i).Key] = res;
            }
            if (m_font.Filepath != null)
                m_font.Resource = m_ui.Content.Load<SpriteFont>(m_font.Filepath);
        }
        public void Update(GameTime gameTime)
        {
            m_wasPressed = m_press;
            m_over = m_bounds.Contains(m_input.MouseX, m_input.MouseY);
            m_press = m_over ? m_wasPressed ? m_input.IsMouseLeftPressed || m_input.IsButtonPressed(Buttons.A) : m_input.IsMouseLeftTriggered || m_input.IsButtonTriggered(Buttons.A) : false;
            if (!m_wasPressed && m_press && OnClick != null)
                OnClick(this);
        }
        public void Draw(GameTime gameTime)
        {
            Texture2D toDraw = m_textures[TextureType.Normal].Resource;
            if (Enabled)
            {
                if (m_press && m_textures.ContainsKey(TextureType.Press))
                    toDraw = m_textures[TextureType.Press].Resource;
                else if (m_over && m_textures.ContainsKey(TextureType.Over))
                    toDraw = m_textures[TextureType.Over].Resource;
            }
            m_ui.SpriteBatch.Draw(toDraw, m_bounds, Enabled ? Color.White : Color.Gray);
            if (m_font.Resource != null)
            {
                Vector2 pos = new Vector2(m_bounds.X, m_bounds.Y);
                Vector2 size = m_font.Resource.MeasureString(m_text);
                pos.X += (m_bounds.Width - size.X) / 2;
                pos.Y += (m_bounds.Height - size.Y) / 2;
                UIHelper.DrawShadowedString(m_ui, m_font.Resource, m_text, pos, m_textTint, m_minTextShadow, m_maxTextShadow);
            }
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the name of the button
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value ?? m_name; }
        }
        /// <summary>
        /// Gets or sets the text drawn in the button.
        /// WARNING: Will overflow if the text does not normally fit.
        /// </summary>
        public string Text
        {
            get { return m_text; }
            set { m_text = value ?? string.Empty; }
        }
        /// <summary>
        /// Gets or sets the bounds of the button
        /// </summary>
        public Rectangle Bounds
        {
            get { return m_bounds; }
            set { m_bounds = value; }
        }
        /// <summary>
        /// Whether or not the control is enabled
        /// </summary>
	public bool Enabled { get; set; }
        #endregion
    }
